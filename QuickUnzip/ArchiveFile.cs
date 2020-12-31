using System;
using System.IO;
using System.IO.Compression;

namespace QuickUnzip
{
    public class ArchiveFile : IDisposable
    {
        public string ArchivePath { get; set; }
        public int ArchiveContentsCount { get; set; }

        private ZipArchive _archive;

        public event EventHandler<ZipProgressArgs> EntryExtracting;

        /// <summary>
        /// Open the archive and get its number of entries
        /// </summary>
        /// <param name="archive">Archive to open</param>
        public ArchiveFile(string archive)
        {
            ArchivePath = archive;

            if (ArchivePath.StartsWith('\"') && ArchivePath.EndsWith('\"'))
            {
                ArchivePath = ArchivePath.Substring(1, ArchivePath.Length - 2);
            }

            _archive = ZipFile.OpenRead(ArchivePath);
            ArchiveContentsCount = _archive.Entries.Count;
        }

        public string GetEntry(int index)
        {
            return _archive.Entries[index].Name;
        }

        public void Extract()
        {
            EntryExtracting?.Invoke(this, new ZipProgressArgs() { Execution = ZipProgressArgsType.CreatingFiles });

            // Create the main folder
            string archiveSourceDir = Path.GetDirectoryName(ArchivePath);
            string mainArchiveDir = Path.Combine(archiveSourceDir, Path.GetFileNameWithoutExtension(ArchivePath));

            if (Directory.Exists(mainArchiveDir))
                Directory.Delete(mainArchiveDir, true);
            Directory.CreateDirectory(mainArchiveDir);
            Directory.SetCurrentDirectory(mainArchiveDir);

            // Start extracting
            for (int i = 0; i < _archive.Entries.Count; i++)
            {
                EntryExtracting?.Invoke(this, new ZipProgressArgs() { Entry = _archive.Entries[i].FullName, Execution = ZipProgressArgsType.Extracting, Index = i });

                if (_archive.Entries[i].FullName.EndsWith('/'))
                    Directory.CreateDirectory(_archive.Entries[i].FullName);
                else
                    _archive.Entries[i].ExtractToFile(_archive.Entries[i].FullName);
            }
        }

        #region Dispose Code
        public void Dispose()
        {
            _archive.Dispose();
        }

        ~ArchiveFile()
        {
            Dispose();
        }
        #endregion
    }
}
