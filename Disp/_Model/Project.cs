using MegariCore.Loader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disp._Model
{
    public class Project
    {
        public VersionInfo VersionInfo;
        public Script MainScript;

        public enum PROJECT_TYPE
        {
            BLANK,
            FULL
        }

        public String FileName;
        public String Name;
        public String Type;
        public String Ver;
        public String ObjectFiles;
        public String Inludes;
        public String Libs;
        public String PrivateResource;
        public String ResourceIncludes;
        public String MakeIncludes;
        public String Compiler;
        public String Includes;
        public String DispCompiler;
        public String Folders { 
            set { Folders = value; } 
            get 
            {
                if (this.Folders == null) 
                { 
                    return "";
                }
                else
                {
                    return Folders;
                }
            } 
        }


        public Project(String ProjectName, String FileName, PROJECT_TYPE ProjectType, String ProjectVersion, String Icon)
        {
            this.Name = ProjectName;
            this.FileName = FileName;
            this.Type = ProjectType.ToString();
            this.Ver = ProjectVersion;
        }

        public static IniFile LoadDefault(Project DataProject, VersionInfo DataVersion, Script DataScript)
        {
            IniFile inifile = new IniFile();

            Section Project = new Section("Project");
            Project.keys.Add(new Key("FileName", DataProject.FileName));
            Project.keys.Add(new Key("Name", DataProject.Name));
            Project.keys.Add(new Key("Type", DataProject.Type));
            Project.keys.Add(new Key("Ver", DataProject.Ver));
            Project.keys.Add(new Key("ObjFiles", DataProject.ObjectFiles));
            Project.keys.Add(new Key("Includes", DataProject.Includes));
            Project.keys.Add(new Key("Libs", ""));
            Project.keys.Add(new Key("PrivateResource", ""));
            Project.keys.Add(new Key("ResourceIncludes", ""));
            Project.keys.Add(new Key("MakeIncludes", ""));
            Project.keys.Add(new Key("Compiler", ""));
            Project.keys.Add(new Key("DispCompiler", ""));
            Project.keys.Add(new Key("Linker", ""));
            Project.keys.Add(new Key("IsDisp", ""));
            Project.keys.Add(new Key("Icon", ""));
            Project.keys.Add(new Key("ExeOutput", ""));
            Project.keys.Add(new Key("ObjectOutput", ""));
            Project.keys.Add(new Key("LogOutput", ""));
            Project.keys.Add(new Key("LogOutputEnabled", ""));
            Project.keys.Add(new Key("OverrideOutput", ""));
            Project.keys.Add(new Key("OverrideOutputName", ""));
            Project.keys.Add(new Key("HostApplication", ""));
            Project.keys.Add(new Key("UseCustomMakefile", ""));
            Project.keys.Add(new Key("Folders", ""));
            Project.keys.Add(new Key("IncludeVersionInfo", "1"));
            Project.keys.Add(new Key("SupportXPThemes", "1"));
            Project.keys.Add(new Key("CompilerSet", "0"));
            Project.keys.Add(new Key("CompilerSettings", "0000000000000000000000000"));
            Project.keys.Add(new Key("UnitCount", "1")); 
            
            inifile.Sections.Add(Project);

            Section VersionInfoProject = new Section("VersionInfo");
            VersionInfoProject.keys.Add(new Key("Major", "1"));
            VersionInfoProject.keys.Add(new Key("Minor", "1"));
            VersionInfoProject.keys.Add(new Key("Release", "1"));
            VersionInfoProject.keys.Add(new Key("Build", "1"));
            VersionInfoProject.keys.Add(new Key("LanguageID", "1"));
            VersionInfoProject.keys.Add(new Key("CharsetID", "1"));
            VersionInfoProject.keys.Add(new Key("CompanyName", "1"));
            VersionInfoProject.keys.Add(new Key("FileVersion", "1"));
            VersionInfoProject.keys.Add(new Key("FileDescription", "1"));
            VersionInfoProject.keys.Add(new Key("InternalName", "1"));
            VersionInfoProject.keys.Add(new Key("LegalCopyright", "1"));
            VersionInfoProject.keys.Add(new Key("LegalTrademarks", "1"));
            VersionInfoProject.keys.Add(new Key("OriginalFilename", "1"));
            VersionInfoProject.keys.Add(new Key("ProductName", "1"));
            VersionInfoProject.keys.Add(new Key("ProductVersion", "1"));
            VersionInfoProject.keys.Add(new Key("AutoIncBuildNr", "1"));
            VersionInfoProject.keys.Add(new Key("SyncProduct", "1"));

            inifile.Sections.Add(VersionInfoProject);

            Section Script = new Section("Script");
            Script.keys.Add(new Key("FileName", ""));
            Script.keys.Add(new Key("CompileDisp", ""));
            Script.keys.Add(new Key("Folder", ""));
            Script.keys.Add(new Key("Compile", ""));
            Script.keys.Add(new Key("Link", ""));
            Script.keys.Add(new Key("Priority", ""));
            Script.keys.Add(new Key("OverrideBuildCmd", ""));
            Script.keys.Add(new Key("BuildCmd", ""));
            inifile.Sections.Add(Script);

            return inifile;
        }
    }
}
