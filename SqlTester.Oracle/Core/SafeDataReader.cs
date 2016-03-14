using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace SqlTester.Oracle.Core
{
    public class SafeDataReader : IDataReader
    {
        private readonly OracleDataReader _dataReader;

        protected IDataReader DataReader
        {
            get { return _dataReader; }
        }

        public SafeDataReader(OracleDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public string GetString(string name)
        {
            return GetString(_dataReader.GetOrdinal(name));
        }

        public virtual string GetString(int i)
        {
            return _dataReader.IsDBNull(i) ? string.Empty : _dataReader.GetString(i);
        }


        public object GetValue(string name)
        {
            return GetValue(_dataReader.GetOrdinal(name));
        }

        public virtual object GetValue(int i)
        {
            return _dataReader.IsDBNull(i) ? null : _dataReader.GetValue(i);
        }

        public int GetInt32(string name)
        {
            return GetInt32(_dataReader.GetOrdinal(name));
        }

        public virtual int GetInt32(int i)
        {
            return _dataReader.IsDBNull(i) ? 0 : _dataReader.GetInt32(i);
        }

        public int? GetInt32Nullable(int i)
        {
            if (_dataReader.IsDBNull(i))
            {
                return null;
            }

            return _dataReader.GetInt32(i);
        }

        public int? GetInt32Nullable(string name)
        {
            return GetInt32Nullable(_dataReader.GetOrdinal(name));
        }

        public double GetDouble(string name)
        {
            return GetDouble(_dataReader.GetOrdinal(name));
        }

        public virtual double GetDouble(int i)
        {
            return _dataReader.IsDBNull(i) ? 0 : _dataReader.GetDouble(i);
        }

        public double? GetDoubleNullable(int i)
        {
            if (_dataReader.IsDBNull(i))
            {
                return null;
            }

            return _dataReader.GetDouble(i);
        }

        public double? GetDoubleNullable(string name)
        {
            return GetDoubleNullable(_dataReader.GetOrdinal(name));
        }

        public Guid GetGuid(string name)
        {
            return GetGuid(_dataReader.GetOrdinal(name));
        }

        public virtual Guid GetGuid(int i)
        {
            return _dataReader.IsDBNull(i) ? Guid.Empty : _dataReader.GetGuid(i);
        }

        public Guid? GetGuidNullable(int i)
        {
            if (_dataReader.IsDBNull(i))
            {
                return null;
            }

            return _dataReader.GetGuid(i);
        }

        public Guid? GetGuidNullable(string name)
        {
            return GetGuidNullable(_dataReader.GetOrdinal(name));
        }

        public bool Read()
        {
            return _dataReader.Read();
        }

        public bool NextResult()
        {
            return _dataReader.NextResult();
        }

        public void Close()
        {
            _dataReader.Close();
        }

        public int Depth
        {
            get
            {
                return _dataReader.Depth;
            }
        }

        public int FieldCount
        {
            get
            {
                return _dataReader.FieldCount;
            }
        }

        public bool GetBoolean(string name)
        {
            return GetBoolean(_dataReader.GetOrdinal(name));
        }

        public virtual bool GetBoolean(int i)
        {
            return !_dataReader.IsDBNull(i) && _dataReader.GetBoolean(i);
        }

        public bool? GetBooleanNullable(int i)
        {
            if (_dataReader.IsDBNull(i))
            {
                return null;
            }

            return _dataReader.GetBoolean(i);
        }

        public bool? GetBooleanNullable(string name)
        {
            return GetBooleanNullable(_dataReader.GetOrdinal(name));
        }

        public byte GetByte(string name)
        {
            return GetByte(_dataReader.GetOrdinal(name));
        }

        public virtual byte GetByte(int i)
        {
            return _dataReader.IsDBNull(i) ? (byte)0 : _dataReader.GetByte(i);
        }

        public byte? GetByteNullable(int i)
        {
            if (_dataReader.IsDBNull(i))
            {
                return null;
            }

            return _dataReader.GetByte(i);
        }

        public byte? GetByteNullable(string name)
        {
            return GetByteNullable(_dataReader.GetOrdinal(name));
        }

        public long GetBytes(string name, long fieldOffset, byte[] buffer, int bufferOffset, int length)
        {
            return GetBytes(_dataReader.GetOrdinal(name), fieldOffset, buffer, bufferOffset, length);
        }

        public virtual long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferOffset, int length)
        {
            return _dataReader.IsDBNull(i) ? 0 : _dataReader.GetBytes(i, fieldOffset, buffer, bufferOffset, length);
        }

        public char GetChar(string name)
        {
            return GetChar(_dataReader.GetOrdinal(name));
        }

        public virtual char GetChar(int i)
        {
            return _dataReader.IsDBNull(i) ? char.MinValue : _dataReader.GetChar(i);
        }

        public char? GetCharNullable(int i)
        {
            if (_dataReader.IsDBNull(i))
            {
                return null;
            }

            return _dataReader.GetChar(i);
        }

        public char? GetCharNullable(string name)
        {
            return GetCharNullable(_dataReader.GetOrdinal(name));
        }

        public long GetChars(string name, long fieldOffset, char[] buffer, int bufferOffset, int length)
        {
            return GetChars(_dataReader.GetOrdinal(name), fieldOffset, buffer, bufferOffset, length);
        }

        public virtual long GetChars(int i, long fieldOffset, char[] buffer, int bufferOffset, int length)
        {
            return _dataReader.IsDBNull(i) ? 0 : _dataReader.GetChars(i, fieldOffset, buffer, bufferOffset, length);
        }

        public IDataReader GetData(string name)
        {
            return GetData(_dataReader.GetOrdinal(name));
        }

        public virtual IDataReader GetData(int i)
        {
            return _dataReader.GetData(i);
        }

        public string GetDataTypeName(string name)
        {
            return GetDataTypeName(_dataReader.GetOrdinal(name));
        }

        public virtual string GetDataTypeName(int i)
        {
            return _dataReader.GetDataTypeName(i);
        }

        public virtual DateTime GetDateTime(string name)
        {
            return GetDateTime(_dataReader.GetOrdinal(name));
        }

        public virtual DateTime GetDateTime(int i)
        {
            return _dataReader.IsDBNull(i) ? DateTime.MinValue : _dataReader.GetDateTime(i);
        }

        public DateTime? GetDateTimeNullable(int i)
        {
            if (_dataReader.IsDBNull(i))
            {
                return null;
            }

            return _dataReader.GetDateTime(i);
        }

        public DateTime? GetDateTimeNullable(string name)
        {
            return GetDateTimeNullable(_dataReader.GetOrdinal(name));
        }

        public decimal GetDecimal(string name)
        {
            return GetDecimal(_dataReader.GetOrdinal(name));
        }

        public virtual decimal GetDecimal(int i)
        {
            return _dataReader.IsDBNull(i) ? 0 : _dataReader.GetDecimal(i);
        }

        public decimal? GetDecimalNullable(int i)
        {
            if (_dataReader.IsDBNull(i))
            {
                return null;
            }

            return _dataReader.GetDecimal(i);
        }

        public decimal? GetDecimalNullable(string name)
        {
            return GetDecimalNullable(_dataReader.GetOrdinal(name));
        }

        public Type GetFieldType(string name)
        {
            return GetFieldType(_dataReader.GetOrdinal(name));
        }

        public virtual Type GetFieldType(int i)
        {
            return _dataReader.GetFieldType(i);
        }

        public float GetFloat(string name)
        {
            return GetFloat(_dataReader.GetOrdinal(name));
        }

        public virtual float GetFloat(int i)
        {
            return _dataReader.IsDBNull(i) ? 0 : _dataReader.GetFloat(i);
        }

        public float? GetFloatNullable(int i)
        {
            if (_dataReader.IsDBNull(i))
            {
                return null;
            }

            return _dataReader.GetFloat(i);
        }

        public float? GetFloatNullable(string name)
        {
            return GetFloatNullable(_dataReader.GetOrdinal(name));
        }

        public short GetInt16(string name)
        {
            return GetInt16(_dataReader.GetOrdinal(name));
        }

        public virtual short GetInt16(int i)
        {
            return _dataReader.IsDBNull(i) ? (short)0 : _dataReader.GetInt16(i);
        }

        public short? GetInt16Nullable(int i)
        {
            if (_dataReader.IsDBNull(i))
            {
                return null;
            }

            return _dataReader.GetInt16(i);
        }

        public short? GetInt16Nullable(string name)
        {
            return GetInt16Nullable(_dataReader.GetOrdinal(name));
        }

        public long GetInt64(string name)
        {
            return GetInt64(_dataReader.GetOrdinal(name));
        }

        public virtual long GetInt64(int i)
        {
            return _dataReader.IsDBNull(i) ? 0 : _dataReader.GetInt64(i);
        }

        public long? GetInt64Nullable(int i)
        {
            if (_dataReader.IsDBNull(i))
            {
                return null;
            }

            return _dataReader.GetInt64(i);
        }

        public long? GetInt64Nullable(string name)
        {
            return GetInt64Nullable(_dataReader.GetOrdinal(name));
        }

        public virtual string GetName(int i)
        {
            return _dataReader.GetName(i);
        }

        public int GetOrdinal(string name)
        {
            return _dataReader.GetOrdinal(name);
        }

        public DataTable GetSchemaTable()
        {
            return _dataReader.GetSchemaTable();
        }

        public int GetValues(object[] values)
        {
            return _dataReader.GetValues(values);
        }

        public bool IsClosed
        {
            get
            {
                return _dataReader.IsClosed;
            }
        }

        public virtual bool IsDBNull(int i)
        {
            return _dataReader.IsDBNull(i);
        }

        // ReSharper disable once InconsistentNaming
        public virtual bool IsDBNull(string name)
        {
            var index = GetOrdinal(name);
            return IsDBNull(index);
        }

        public object this[string name]
        {
            get
            {
                object val = _dataReader[name];
                return DBNull.Value.Equals(val) ? null : val;
            }
        }

        public virtual object this[int i]
        {
            get
            {
                return _dataReader.IsDBNull(i) ? null : _dataReader[i];
            }
        }

        public int RecordsAffected
        {
            get
            {
                return _dataReader.RecordsAffected;
            }
        }

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _dataReader.Dispose();
                }
            }
            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~SafeDataReader()
        {
            Dispose(false);
        }
    }
}