using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AccessMatrix
{
    class FolderSecurity
    {
        private bool secure;

        public FolderSecurity()
        {
            secure = false;
        }

        private void CloseTheFiles(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string filePath in files)
            {
                DirectorySecurity securityDirrectory = Directory.GetAccessControl(filePath);
                securityDirrectory.SetAccessRule(
                new FileSystemAccessRule(
                    Environment.UserName,
                    FileSystemRights.FullControl,
                    AccessControlType.Deny)
                    );
                Directory.SetAccessControl(filePath, securityDirrectory);
            }
        }

        private void OpenTheFiles(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string filePath in files)
            {
                DirectorySecurity securityDirrectory = Directory.GetAccessControl(filePath);
                securityDirrectory.RemoveAccessRule(
                new FileSystemAccessRule(
                    Environment.UserName,
                    FileSystemRights.FullControl,
                    AccessControlType.Deny)
                    );
                Directory.SetAccessControl(filePath, securityDirrectory);
            }
        }

        private void CloseADirrectory(string path)
        {
            CloseTheFiles(path);

            DirectorySecurity directorySecurity = Directory.GetAccessControl(path);
            FileSystemAccessRule fsa = new FileSystemAccessRule(
                Environment.UserName,
                FileSystemRights.FullControl,
                AccessControlType.Deny
                );

            directorySecurity.AddAccessRule(fsa);
            Directory.SetAccessControl(path, directorySecurity);
        }

        private void OpenADirrectory(string path)
        {
            DirectorySecurity directorySecurity = Directory.GetAccessControl(path);
            FileSystemAccessRule fsa = new FileSystemAccessRule(
                Environment.UserName,
                FileSystemRights.FullControl,
                AccessControlType.Deny
                );

            directorySecurity.RemoveAccessRule(fsa);
            Directory.SetAccessControl(path, directorySecurity);

            OpenTheFiles(path);
        }

        public void RecursiveSecurityUp(string path)
        {
            string[] directories = Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                RecursiveSecurityUp(directory);
            }
            CloseADirrectory(path);
        }

        public void RecursiveSecurityDown(string path)
        {
            OpenADirrectory(path);
            string[] directories = Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                RecursiveSecurityDown(directory);
            }
        }
    }
}
