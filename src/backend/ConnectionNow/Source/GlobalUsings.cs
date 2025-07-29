#region System
global using System.ComponentModel.DataAnnotations;
#endregion

#region Microsoft
global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
#endregion

#region ConnectionNow
global using ConnectionNow.Source.Setup.Extensions;
global using ConnectionNow.Source.Setup.Pipeline;
global using ConnectionNow.Source.Core.Domain.Interface;
global using ConnectionNow.Source.Core.Domain.Model;
global using ConnectionNow.Source.Core.Infrastructure.Configuration;
global using ConnectionNow.Source.Core.Infrastructure.Data.Context;
global using ConnectionNow.Source.Core.Infrastructure.Data.Repositories;
global using ConnectionNow.Source.Core.Infrastructure.Data.UoW;
#endregion
