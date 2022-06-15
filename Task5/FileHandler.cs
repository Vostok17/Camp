using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class FileHandler : IDisposable
    {
        private readonly string _path;
        private readonly string _dir;
        private FileIterator _iterator;

        private FileHandler() { }
        public FileHandler(string filename)
        {
            if (filename != null)
            {
                // Relative path to the project folder.
                _dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();

                _path = Path.Combine(_dir, "assets", filename);
            }
        }

        #region Object methods

        public override string ToString()
        {
            return $"Opetates on: {_path}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is FileHandler other)
            {
                return _path == other._path;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return _path.GetHashCode();
        }

        #endregion

        #region Methods

        public void WriteVector(Vector v)
        {
            // Close file iterator which operates on the same file.
            if (_iterator != null && !_iterator.IsDisposed)
                _iterator.Dispose();

            using (StreamWriter sw = new StreamWriter(_path))
            {
                sw.Write(string.Join(' ', v));
            }
        }
        public Vector ReadVector()
        {
            int[] arr;
            using (StreamReader sr = new StreamReader(_path))
            {
                arr = sr.ReadLine().Trim().Split()
                .Select(x => int.Parse(x))
                .ToArray();
            }
            return new Vector(arr);
        }
        public List<string> Split(int numberOfClusters)
        {
            var files = new List<string>();
            var streamWriters = new List<StreamWriter>();

            for (int i = 0; i < numberOfClusters; i++)
            {
                string filePath = Path.Combine(_dir, "assets", $"arr{i}.txt");
                files.Add(filePath);
                streamWriters.Add(new StreamWriter(filePath));
            }

            OpenIterator();

            while (!_iterator.IsDisposed)
            {
                foreach (StreamWriter sw in streamWriters)
                {
                    int? num = ReadNext();
                    if (num is null)
                        break;
                    sw.Write(num + " ");
                }
            }

            foreach (StreamWriter sw in streamWriters)
            {
                sw.Dispose();
            }
            return files;
        }
        public void Merge(List<string> files, bool descending = false)
        {
            var fileHandlers = new List<FileHandler>();

            foreach (string file in files)
            {
                var fh = new FileHandler(file);
                fh.OpenIterator();
                fileHandlers.Add(fh);
            }

            var queue = new PriorityQueue<(FileHandler, int), int>();
            foreach (FileHandler fh in fileHandlers)
            {
                AddToQueue(fh);
            }

            using (StreamWriter mainFile = new StreamWriter(_path))
            {
                while (queue.Count > 0)
                {
                    var (fh, numToWrite) = queue.Dequeue();
                    mainFile.Write(numToWrite + " ");

                    AddToQueue(fh);
                }
            }

            foreach (FileHandler fh in fileHandlers)
            {
                fh.Dispose();
            }

            void AddToQueue(FileHandler fh)
            {
                int? num = fh.ReadNext();
                if (num != null)
                {
                    int numToAdd = (int)num;
                    queue.Enqueue((fh, numToAdd), numToAdd);
                }
            }
        }
        public void OpenIterator() => _iterator = new FileIterator(_path);
        public int? ReadNext() => _iterator.ReadNext();
        public bool IsDisposed => _iterator.IsDisposed;
        public void Dispose()
        {
            _iterator.Dispose();
        }

        #endregion

        private class FileIterator : IDisposable
        {
            private StreamReader _sr;
            public bool IsDisposed = true;

            private FileIterator() { }
            public FileIterator(string path)
            {
                Open(path);
            }

            public int? ReadNext()
            {
                if (IsDisposed)
                    return null;

                // Skip non-digits.
                char c;
                while (!char.IsDigit((char)_sr.Peek()) && !_sr.EndOfStream)
                {
                    _sr.Read();
                }

                if (_sr.EndOfStream)
                {
                    _sr.Dispose();
                    IsDisposed = true;
                    return null;
                }

                var buffer = new StringBuilder();
                while (char.IsDigit(c = (char)_sr.Read()))
                {
                    buffer.Append(c);
                }
                return Convert.ToInt32(buffer.ToString());
            }
            public void Open(string path)
            {
                _sr = new StreamReader(path);
                IsDisposed = false;
            }
            public void Dispose()
            {
                _sr.Dispose();
                IsDisposed = true;
            }
        }
    }
}
