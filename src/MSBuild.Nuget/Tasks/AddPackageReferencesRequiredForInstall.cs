// Copyright (c) 74Bravo LLC and Contributors. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project or repository root for license information.


using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenStrata.MSBuild.Nuget.Tasks
{
    public class AddPackageReferencesRequiredForInstall : NuspecTaskBase
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

                    Log.LogMessage($"Processing Project Reference : {taskItem.ItemSpec}");

                    var id = taskItem.ItemSpec;
                    var version = taskItem.GetMetadata("Version") ?? "1.0.0";

                    // Validate dependency information
                    if (string.IsNullOrWhiteSpace(id))
                    {
                        Log.LogWarning($"Skipping package reference with empty or null ID");
                        continue;
                    }

                    if (!IsValidVersion(version))
                    {
                        Log.LogWarning($"Package reference '{id}' has invalid version '{version}', using default version 1.0.0");
                        version = "1.0.0";
                    }

                    AddRootDependency(id, version);

                }

            }
            return true;
        }


    }
}
