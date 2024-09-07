// Copyright (c) 74Bravo LLC and Contributors. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project or repository root for license information.

using Microsoft.Build.Framework;
//using NuGet.Frameworks;
//using NuGet.Packaging;
using OpenStrata.MSBuild.Tasks;
using OpenStrata.Nuget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace OpenStrata.MSBuild.Nuget.Tasks
{
    public class AddNoTargetProjectReferencesToNuspec : NuspecTaskBase
    {

        [Required]
        public ITaskItem[] ProjectReferences { get; set; }

        public override bool ExecuteNuspecTask()
        {
            if (ProjectReferences != null)
            {
                //var dependencies = new List<dependency>();
                //foreach (ITaskItem taskItem in ProjectReferences)
                //{
                //    var id = taskItem.GetMetadata("NugetPackageId");
                //    var version = taskItem.GetMetadata("ProjectVersion");
                //    //TODO: validate dendency information
                //    dependencies.Add(new dependency()
                //    {
                //        id = id,
                //        version = version
                //    });
                //}
                //this.NuspecPackage.AddDependencies(dependencies);
                //return true;


                Log.LogMessage($"Starting Update to Nuspec file located at {AbsoluteNuspecPath}");

                //var reader = new NuspecFile(AbsoluteNuspecPath);

                //var _dependencies = reader.GetDependencyGroups();

                //foreach (PackageDependencyGroup dp in _dependencies)
                //{
                //    if (dp.TargetFramework == NuGetFramework.AnyFramework)
                //    {
                //        var str = "";
                //    }
                //}

                //var ns = NuspecPackage.MetadataNode.GetDefaultNamespace().NamespaceName;
                //Log.LogMessage($"Nuspec file namespace is {ns}");

                //var dependencyNode = NuspecPackage.MetadataNode
                //    .Element(XName.Get(Restratify.Nuspec.NuspecFile.Dependencies, ns));

                //if (dependencyNode == null)
                //{
                //    Log.LogMessage($"Adding Dependencies Element");

                //    dependencyNode = new XElement(XName.Get(Restratify.Nuspec.NuspecFile.Dependencies, ns));
                //    NuspecPackage.MetadataNode.Add(dependencyNode);
                //}
                //else
                //{
                //    Log.LogMessage($"Dependencies Element already exists");
                //}


                Log.LogMessage($"Processing Project References Started.");

                foreach (ITaskItem taskItem in ProjectReferences)
                {

                    Log.LogMessage($"Processing Project Reference : {taskItem.ItemSpec}");

                    var id = taskItem.GetMetadata("NugetPackageId");
                    var version = taskItem.GetMetadata("ProjectVersion");

                    ////TODO: validate dependency information
                    ///
                    AddRootDependency(id, version);


                }

            }
            return true;
        }

    }
}
