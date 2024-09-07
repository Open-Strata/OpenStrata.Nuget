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
    public class AddPackageReferencesAsRootDependencies : NuspecTaskBase
    {

        [Required]
        public ITaskItem[] PackageReferences { get; set; }

        public override bool ExecuteNuspecTask()
        {
            if (PackageReferences != null)
            {

                Log.LogMessage($"Starting Update to Nuspec file located at {AbsoluteNuspecPath}");


                Log.LogMessage($"Processing Project References Started.");

                foreach (ITaskItem taskItem in PackageReferences)
                {

                    var id = taskItem.ItemSpec;
                    var version = taskItem.GetMetadata("Version") ?? "1.0.0";
                    var isImplicitlyDefined = taskItem.GetMetadata("IsImplicitlyDefined")?.ToLower() ?? "false";
                    var privateAssets = taskItem.GetMetadata("PrivateAssets")?.ToLower() ?? "none";

                    Log.LogMessage($"Processing Project Reference : {id} using version = {version}, isImplicitlyDefined = {isImplicitlyDefined} and privateAssets = {privateAssets}");

                    ////TODO: validate dependency information
                    ///

                    if (isImplicitlyDefined != "true" && privateAssets != "all" )
                    {
                        AddRootDependency(id, version);
                    }
                }

            }
            return true;
        }

    }
}
