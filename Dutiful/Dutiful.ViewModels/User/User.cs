using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutiful.ViewModels.User;

public record UserViewModel(Guid Id, string UserName, string FullName, string Email, string MobileNo, bool IsActive, DateTime RegisterDate);