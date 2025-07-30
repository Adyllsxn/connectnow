#region System
global using System.ComponentModel.DataAnnotations;
global using System.Text;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
#endregion

#region Microsoft
global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
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
global using ConnectionNow.Source.Core.Application.Interface;
global using ConnectionNow.Source.Core.Application.Service;
global using ConnectionNow.Source.Core.Application.Configuration;
#endregion
