using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FilmesAPI.Autorizacao
{
    public class IdadeMinimaHandler : AuthorizationHandler<IdadeMinimaRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        IdadeMinimaRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
                return Task.CompletedTask;

            DateTime dataDeNascimento = Convert.ToDateTime(context.User
                .FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);

            int idadeObtida = DateTime.Today.Year - dataDeNascimento.Year;

            if (dataDeNascimento > DateTime.Today.AddYears(-idadeObtida))
                idadeObtida--;
            if (idadeObtida >= requirement.IdadeMinima) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}