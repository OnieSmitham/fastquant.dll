﻿// Copyright (c) FastQuant Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.IO;
using System;

namespace FastQuant
{
    public static class Installation
    {
        public static DirectoryInfo ApplicationDataDir => Directory.CreateDirectory(Path.Combine(GetApplicationDataPath(), "SmartQuant Ltd", "OpenQuant 2014"));

        public static DirectoryInfo DataDir => Directory.CreateDirectory(Path.Combine(GetApplicationDataPath(), "SmartQuant Ltd", "OpenQuant 2014", "data"));

        public static DirectoryInfo ConfigDir => Directory.CreateDirectory(Path.Combine(GetApplicationDataPath(), "SmartQuant Ltd", "OpenQuant 2014", "config"));

        public static DirectoryInfo LogsDir => Directory.CreateDirectory(Path.Combine(ApplicationDataDir.FullName, "logs"));

        private static string GetApplicationDataPath()
        {
#if NET451            
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
#else
            return Path.Combine(Environment.GetEnvironmentVariable("HOME") ?? Environment.GetEnvironmentVariable("USERPROFILE"), "AppData", "Roaming");
#endif
        }
    }
}
