// Copyright (c) 74Bravo LLC and Contributors. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project or repository root for license information.

using System;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace OpenStrata.MSBuild.Tasks
{

    public abstract class BaseTask : Microsoft.Build.Utilities.Task
    {

        private string taskName;

        public sealed override bool Execute()
        {
            try
            {

                taskName = this.GetType().Name;

                Log.LogMessage(MessageImportance.Normal, $"OpenStrata Task: {taskName} has started.");
                
                // Execute the specific task implementation
                if (!ExecuteTask())
                {
                    Log.LogMessage(MessageImportance.High, $"OpenStrata Task: {taskName} did not complete successfully.");
                    return false;
                }
                
                Log.LogMessage(MessageImportance.Normal, $"OpenStrata Task: {taskName} has finished successfully.");
                return true;
            }
            catch (Exception ex)
            {

                return TaskFailed(ex);
            }
        }

        public abstract bool ExecuteTask();

        public bool TaskFailed(string message)
        {
            Log.LogError($"OpenStrata Task: {taskName} : Failed : {message}");
            return false;
        }

        public bool TaskFailed(Exception exception)
        {

            Log.LogError(new StringBuilder()
                       .AppendLine($"OpenStrata Task: {taskName} : Failed : {exception.Source}")
                       .BuildExceptionMessageBlock(exception)
                       .ToString());

            return false;
        }

        public bool TaskSuccess(string message = "Finished successfully.")
        {
            Log.LogMessage($"OpenStrata Task: {taskName} : Success : {message}");
            return true;
        }

        public bool TaskFinishedWithWarning(string message)
        {
            Log.LogWarning($"OpenStrata Task: {taskName} : Warning : {message}");
            return true;
        }

        public void LogMessage(string msg)
        {
            this.Log.LogMessage(msg);
        }

        /// <summary>
        /// Validates if a version string is in a proper format
        /// </summary>
        /// <param name="version">Version string to validate</param>
        /// <returns>True if version is valid, false otherwise</returns>
        protected bool IsValidVersion(string version)
        {
            if (string.IsNullOrWhiteSpace(version))
                return false;

            // Basic validation for semantic versioning (allows wildcards and pre-release)
            // Examples: 1.0.0, 1.2.3-alpha, 2.0.*, [1.0,2.0)
            if (version.Contains("[") || version.Contains("(") || version.Contains("]") || version.Contains(")"))
            {
                // Range notation - basic validation
                return version.Length > 2;
            }

            // Check for basic version patterns
            return System.Text.RegularExpressions.Regex.IsMatch(version, 
                @"^\d+(\.\d+)*(\.\*)?(-[a-zA-Z0-9\-\.]+)?$");
        }

    }

    public static class BaseTaskExtensions
    {

        public static StringBuilder BuildExceptionMessageBlock(this StringBuilder sb, Exception ex)
        {
            if (ex == null) return sb;
            return sb.BuildExceptionMessageBlock(ex.InnerException)
                .AppendLine(ex.Message)
                .AppendLine(ex.StackTrace);
        }

        public static void Log(this TaskLoggingHelper logger, string msg)
        {
            logger.LogMessage(msg);
        }


    }


}
