using System;
using System.IO;
using SevenZipExtractor;
using System.IO.Compression;

namespace QuickUnzip
{
    public class ArchiveFile : IDisposable
    {
        public string ArchivePath { get; set; }
        public int ArchiveContentsCount { get; set; }

        private SevenZipExtractor.ArchiveFile archive;

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

            this.archive = new SevenZipExtractor.ArchiveFile(ArchivePath);
            ArchiveContentsCount = this.archive.Entries.Count;
        }

        public string GetEntry(int index)
        {
            return Path.GetFileNameWithoutExtension(archive.Entries[index].FileName);
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
            for (int i = 0; i < archive.Entries.Count; i++)
            {
                EntryExtracting?.Invoke(this, new ZipProgressArgs() { Entry = archive.Entries[i].FileName, Execution = ZipProgressArgsType.Extracting, Index = i });

                if (archive.Entries[i].FileName.EndsWith('/'))
                    Directory.CreateDirectory(archive.Entries[i].FileName);
                else
                    archive.Entries[i].Extract(archive.Entries[i].FileName);
            }
        }

        #region Dispose Code
        public void Dispose()
        {
            archive.Dispose();
        }

        ~ArchiveFile()
        {
            Dispose();
        }
        #endregion
    }
}
