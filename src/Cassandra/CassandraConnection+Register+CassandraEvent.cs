//
//      Copyright (C) 2012 DataStax Inc.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
﻿using System;
using System.Net;

namespace Cassandra
{
    public class CassandraEventArgs : EventArgs
    {
    }

    public class TopologyChangeEventArgs : CassandraEventArgs
    {
        public enum Reason
        {
            NewNode,
            RemovedNode
        };

        public Reason What;
        public IPAddress Address;
    }

    public class StatusChangeEventArgs: CassandraEventArgs
    {
        public enum Reason
        {
            Up,
            Down
        };
        public Reason What;
        public IPAddress Address;
    }

    public class SchemaChangeEventArgs:CassandraEventArgs
    {
        public enum Reason
        {
            Created,
            Updated,
            Dropped
        };
        public Reason What;
        public string Keyspace;
        public string Table;
    }

    public delegate void CassandraEventHandler(object sender, CassandraEventArgs e);

    [Flags]
    public enum CassandraEventType { TopologyChange = 0x01, StatusChange = 0x02, SchemaChange = 0x03 }
}