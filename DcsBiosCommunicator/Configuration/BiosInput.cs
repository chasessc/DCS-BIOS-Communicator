﻿using System;
using System.Collections.Generic;
using DcsBios.Communicator.Configuration.JsonConverters;
using Newtonsoft.Json;

namespace DcsBios.Communicator.Configuration
{
    [JsonConverter(typeof(InputConverter))]
    public abstract class BiosInput
    {
        // TODO: enumify
        public string Interface { get; set; } = null!;

        private static readonly Dictionary<string, Type> Types = new()
        {
            [InputFixedStep.InterfaceType] = typeof(InputFixedStep),
            [InputSetState.InterfaceType] = typeof(InputSetState),
            [InputAction.InterfaceType] = typeof(InputAction),
            [InputVariableStep.InterfaceType] = typeof(InputVariableStep),
        };

        public static Type GetTypeForType(in string type)
        {
            return Types[type];
        }
    }
}