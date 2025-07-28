﻿using System.IO;
using System.Reflection;

namespace Binner.Common.IO
{
    /// <summary>
    /// Resource loading library
    /// </summary>
    public static class ResourceLoader
    {
        /// <summary>
        /// Load an embedded resource as a string
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string LoadResourceString(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return LoadResourceString(assembly, name);
        }

        /// <summary>
        /// Load an embedded resource as a string
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string LoadResourceString(Assembly assembly, string name)
        {
            var resourceName = GetResourceName(assembly, name);
            using var stream = assembly.GetManifestResourceStream(resourceName) ?? throw new FileNotFoundException($"Resource named '{name}' not found.", nameof(name));
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        /// <summary>
        /// Load an embedded resource stream
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Stream LoadResourceStream(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return LoadResourceStream(assembly, name);
        }

        /// <summary>
        /// Load an embedded resource stream
        /// </summary>
        /// <param name="assembly">Assembly in which the resource is located</param>
        /// <param name="name">Name of the resource (full namespace without assembly name)</param>
        /// <param name="assemblyName">Optional assembly namespace name, if different from the assembly's name</param>
        /// <returns></returns>
        public static Stream LoadResourceStream(Assembly assembly, string name, string? assemblyName = null)
        {
            var resourceName = string.Empty;
            if (string.IsNullOrEmpty(assemblyName))
                resourceName = GetResourceName(assembly, name);
            else
                resourceName = GetResourceName(assemblyName, name);
            return assembly.GetManifestResourceStream(resourceName) ?? throw new FileNotFoundException($"Resource named '{name}' not found.", nameof(name));
        }

        /// <summary>
        /// Load an embedded resource and get the bytes
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static byte[] LoadResourceBytes(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return LoadResourceBytes(assembly, name);
        }

        /// <summary>
        /// Load an embedded resource and get the bytes
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static byte[] LoadResourceBytes(Assembly assembly, string name)
        {
            var resourceName = GetResourceName(assembly, name);
            using var stream = assembly.GetManifestResourceStream(resourceName) ?? throw new FileNotFoundException($"Resource named '{name}' not found.", nameof(name));
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return buffer;
        }

        private static string GetResourceName(Assembly assembly, string resourceName) => $"{assembly.GetName().Name}.{resourceName}";
        private static string GetResourceName(string assemblyName, string resourceName) => $"{assemblyName}.{resourceName}";
    }
}
