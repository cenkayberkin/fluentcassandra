/**
 * Autogenerated by Thrift Compiler (0.9.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FluentCassandra.Thrift;
using FluentCassandra.Thrift.Collections;
using System.Runtime.Serialization;
using FluentCassandra.Thrift.Protocol;
using FluentCassandra.Thrift.Transport;

namespace FluentCassandra.Apache.Cassandra
{

  /// <summary>
  /// Note that the timestamp is only optional in case of counter deletion.
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Deletion : TBase
  {
    private long _timestamp;
    private byte[] _super_column;
    private SlicePredicate _predicate;

    public long Timestamp
    {
      get
      {
        return _timestamp;
      }
      set
      {
        __isset.timestamp = true;
        this._timestamp = value;
      }
    }

    public byte[] Super_column
    {
      get
      {
        return _super_column;
      }
      set
      {
        __isset.super_column = true;
        this._super_column = value;
      }
    }

    public SlicePredicate Predicate
    {
      get
      {
        return _predicate;
      }
      set
      {
        __isset.predicate = true;
        this._predicate = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool timestamp;
      public bool super_column;
      public bool predicate;
    }

    public Deletion() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.I64) {
              Timestamp = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              Super_column = iprot.ReadBinary();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.Struct) {
              Predicate = new SlicePredicate();
              Predicate.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("Deletion");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.timestamp) {
        field.Name = "timestamp";
        field.Type = TType.I64;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(Timestamp);
        oprot.WriteFieldEnd();
      }
      if (Super_column != null && __isset.super_column) {
        field.Name = "super_column";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteBinary(Super_column);
        oprot.WriteFieldEnd();
      }
      if (Predicate != null && __isset.predicate) {
        field.Name = "predicate";
        field.Type = TType.Struct;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        Predicate.Write(oprot);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("Deletion(");
      sb.Append("Timestamp: ");
      sb.Append(Timestamp);
      sb.Append(",Super_column: ");
      sb.Append(Super_column);
      sb.Append(",Predicate: ");
      sb.Append(Predicate== null ? "<null>" : Predicate.ToString());
      sb.Append(")");
      return sb.ToString();
    }

  }

}
