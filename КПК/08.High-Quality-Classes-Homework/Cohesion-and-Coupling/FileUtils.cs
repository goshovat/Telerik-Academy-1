// <copyright file="FileUtils.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
namespace Utils
{
    using System;

    /// <summary>
    /// Describe utils for files.
    /// </summary>
    internal static class FileUtils
    {
        /// <summary>
        /// Get file extension from the file.
        /// </summary>
        /// <param name="fileName">The name of the file</param>
        /// <returns>Returns the file's extension.</returns>
        /// <exception cref="System.ArgumentException">When fileName is null or white space.</exception>
        public static string GetFileExtension(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name cannot be null or empty.");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        /// <summary>
        /// Get file name without extension.
        /// </summary>
        /// <param name="fileName">The name of the file</param>
        /// <returns>Returns the file's name without extension.</returns>
        /// <exception cref="System.ArgumentException">When fileName is null or white space.</exception>
        public static string GetFileNameWithoutExtension(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name cannot be null or empty.");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");

            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
