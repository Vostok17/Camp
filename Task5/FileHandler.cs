using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class FileHandler : IDisposable
    {
        private string _path;
        private string _dir;
        private FileIterator _iterator;

        public FileHandler() : this(null) { }
        public FileHandler(string filename)
        {
            if (filename != null)
            {
                // Relative path to the project folder.
                _dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();

                _path = Path.Combine(_dir, "assets", filename);
                _iterator = new FileIterator(_path);
            }
        }

        public override string ToString()
        {
            return $"Opetates on: {_path}";
        }

        public void WriteVector(Vector v)
        {
            if (!_iterator.IsDisposed)
                _iterator.Dispose();

            using (StreamWriter sw = new StreamWriter(_path))
            {
                // Write the length of the vector.
                sw.WriteLine(v.Lenght);

                sw.Write(string.Join(' ', v));
            }
        }
        public Vector ReadVector()
        {
            int[] arr;
            using (StreamReader sr = new StreamReader(_path))
            {
                // Read the length of the vector.
                int length = Convert.ToInt32(sr.ReadLine());

                if (length == 0)
                    return new Vector();

                arr = sr.ReadLine().Trim().Split()
                .Select(x => int.Parse(x))
                .ToArray();

            }
            return new Vector(arr);
        }

        public (string file1, string file2) Split()
        {
            string file1 = Path.Combine(_dir, "assets", "arr1.txt"),
                file2 = Path.Combine(_dir, "assets", "arr2.txt");

            int length;
            using (StreamReader sr = new StreamReader(_path))
            {
                length = Convert.ToInt32(sr.ReadLine());
            }

            Write(file1, length / 2);
            Write(file2, length - length / 2);

            return (file1, file2);

            void Write(string path, int length)
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(length);
                    for (int i = 0; i < length; i++)
                    {
                        int? num = ReadNext();
                        if (num is null)
                        {
                            throw new Exception($"Invalid data in file: {path}");
                        }
                        sw.Write(num + " ");
                    }
                }
            }
        }
        public void Merge(string file1, string file2)
        {
            var fh1 = new FileHandler(file1);
            var fh2 = new FileHandler(file2);

            int length = fh1.GetVectorSize() + fh2.GetVectorSize();

            using (StreamWriter sw = new StreamWriter(_path))
            {
                // Write the length of the vector
                sw.WriteLine(length);

                int? a1 = fh1.ReadNext(), a2 = fh2.ReadNext();

                while (!fh1.IsDisposed && !fh2.IsDisposed)
                {
                    if (a1 <= a2)
                    {
                        sw.Write(a1 + " ");
                        a1 = fh1.ReadNext();
                    }
                    else
                    {
                        sw.Write(a2 + " ");
                        a2 = fh2.ReadNext();
                    }
                }

                while (!fh1.IsDisposed)
                {
                    sw.Write(a1 + " ");
                    a1 = fh1.ReadNext();
                }
                while (!fh2.IsDisposed)
                {
                    sw.Write(a2 + " ");
                    a2 = fh2.ReadNext();
                }
            }
        }

        public int? ReadNext() => _iterator.ReadNext();
        public void Restart() => _iterator.Restart(_path);
        public bool IsDisposed => _iterator.IsDisposed;
        public int GetVectorSize()
        {
            int size;
            using (StreamReader sr = new StreamReader(_path))
            {
                size = Convert.ToInt32(sr.ReadLine());
            }
            return size;
        }

        public void Dispose()
        {
            _iterator.Dispose();
        }

        private class FileIterator : IDisposable
        {
            private StreamReader _sr;
            public bool IsDisposed = false;

            public FileIterator(string path)
            {
                Restart(path);
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
            public void Restart(string path)
            {
                _sr = new StreamReader(path);
                IsDisposed = false;

                // Skip line with count of numbers.
                _sr.ReadLine();
            }
            public void Dispose()
            {
                _sr.Dispose();
                IsDisposed = true;
            }
        }
    }
}
