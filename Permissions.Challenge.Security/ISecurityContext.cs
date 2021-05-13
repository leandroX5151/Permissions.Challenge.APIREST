using System;
using System.Collections.Generic;
using System.Text;

namespace Permissions.Challenge.Security
{
    public interface ISecurityContext
    {
        string Username { get; }
        string[] Roles { get; }
    }
}
