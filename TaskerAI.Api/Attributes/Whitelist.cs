namespace TaskerAI.Api.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public sealed class WhitelistAttribute : ValidationAttribute
    {
        private IEnumerable<int> Whitelist { get; }

        public WhitelistAttribute(params int[] whiteList) => this.Whitelist = new List<int>(whiteList);

        public override bool IsValid(object value) => this.Whitelist.Contains((int)value);

        public override string FormatErrorMessage(string name) => $"{name} must have one of these values: {string.Join(", ", this.Whitelist)}";

    }
}
