// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


using Microsoft.AspNet.Http.Security;

namespace Microsoft.AspNet.Security.DataHandler.Serializer
{
    public static class DataSerializers
    {
        static DataSerializers()
        {
            Properties = new PropertiesSerializer();
            Ticket = new TicketSerializer();
        }

        public static IDataSerializer<AuthenticationProperties> Properties { get; private set; }

        public static IDataSerializer<AuthenticationTicket> Ticket { get; private set; }
    }
}
