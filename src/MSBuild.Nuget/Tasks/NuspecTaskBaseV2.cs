// Copyright (c) 74Bravo LLC and Contributors. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project or repository root for license information.

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using OpenStrata.MSBuild.Tasks;
using OpenStrata.Nuget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace OpenStrata.MSBuild.Nuget.Tasks
{

    public abstract class NuspecTaskBase : BaseTask
    {

        [Required]
        public string AbsoluteNuspecPath { get; set; }
        protected virtual bool ValidNuspecPathRequired => true;
        protected virtual bool SaveNuspecAfterExecution => true;

        private NuspecFile _nuspecPackage;
        private bool _loadAttempted = false;

        private bool _nuspecLoadissuccess = false;
        protected bool NuspecLoadedSuccessfully 
        { get
            {
                if (_loadAttempted) return _nuspecLoadissuccess;
                var packLoad = NuspecPackage;
                return _nuspecLoadissuccess;
            }
        }

        protected NuspecFile NuspecPackage
        {
            get
            {
                if (_nuspecPackage == null && !_loadAttempted)
                {
                    _nuspecPackage = NuspecFile.Load(AbsoluteNuspecPath);
                    _nuspecLoadissuccess = true;
                    _loadAttempted = true;
                }
                return _nuspecPackage;
            }
        }
        public override sealed bool ExecuteTask()
        {
            if (ValidNuspecPathRequired && !NuspecLoadedSuccessfully)
            {
                Log.LogError($"Failed to load required nuspec file at path: {AbsoluteNuspecPath}");
                Log.LogMessage(MessageImportance.High, "Task execution cannot continue without a valid nuspec file.");
                return false;
            }
            
            var result = ExecuteNuspecTask();

            if (result && SaveNuspecAfterExecution)
            {
                Log.LogMessage(MessageImportance.Normal, $"Saving changes to nuspec file: {AbsoluteNuspecPath}");
                Log.LogMessage(MessageImportance.Low, $"Updated nuspec content:\n{NuspecPackage.ToString()}");

                try
                {
                    NuspecPackage.Save(AbsoluteNuspecPath);
                    Log.LogMessage(MessageImportance.Normal, "Nuspec file saved successfully.");
                }
                catch (Exception ex)
                {
                    Log.LogError($"Failed to save nuspec file: {ex.Message}");
                    return false;
                }
            }

            return result;
        }

        private string _ns;
        protected String NameSpace
        {
            get
            {
                if (_ns == null)
                {
                    _ns = NuspecPackage.MetadataNode.GetDefaultNamespace().NamespaceName;
                    Log.LogMessage($"Nuspec file namespace is {_ns}");
                }
                return _ns;
            }
        }

        private XElement _dependencyNode;
        protected XElement DependencyNode
        {
            get
            {
                if (_dependencyNode == null){

                    _dependencyNode = NuspecPackage.MetadataNode
                                        .Element(XName.Get(NuspecFile.Dependencies, NameSpace));

                    if (_dependencyNode == null)
                    {
                        Log.LogMessage($"Adding Dependencies Element");

                        _dependencyNode = new XElement(XName.Get(NuspecFile.Dependencies, NameSpace));
                        NuspecPackage.MetadataNode.Add(_dependencyNode);
                    }
                    else
                    {
                        Log.LogMessage($"Dependencies Element already exists");
                    }
                }
                return _dependencyNode;
            }
        }


        protected void AddRootDependency (string id, string version, string targetFramework = "Any")
        {
         

            var newDependency = new XElement(XName.Get(NuspecFile.Dependency, NameSpace));

            newDependency.Add(new XAttribute("id", id));
            newDependency.Add(new XAttribute("version", version));

            Log.LogMessage($"Adding Project Reference Dependency : {id} {version} to the {targetFramework} dependency group");

            var parentNode = DependencyNode?.Elements(XName.Get(NuspecFile.Group,NameSpace))
                ?.Where(x =>
                   x.Attribute(NuspecFile.TargetFramework).Value
                   .Equals(targetFramework,
                       StringComparison.OrdinalIgnoreCase))
                ?.SingleOrDefault();

            if (parentNode == null)
            {
                Log.LogMessage($"Adding New TargetFramework dependency group for {targetFramework}");
                parentNode = new XElement(XName.Get(NuspecFile.Group, NameSpace));
                parentNode.Add(new XAttribute(NuspecFile.TargetFramework,  targetFramework));
                DependencyNode.Add(parentNode);
            }

            parentNode.Add(newDependency);

        }

        public abstract bool ExecuteNuspecTask();

    }
}
