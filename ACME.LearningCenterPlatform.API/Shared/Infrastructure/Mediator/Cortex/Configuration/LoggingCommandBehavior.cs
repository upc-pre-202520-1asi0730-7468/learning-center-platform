using Cortex.Mediator.Commands;

namespace ACME.LearningCenterPlatform.API.Shared.Infrastructure.Mediator.Cortex.Configuration;

public class LoggingCommandBehavior<TCommand> 
    : ICommandPipelineBehavior<TCommand> where TCommand : ICommand
{
    public async Task Handle(
        TCommand command, 
        CommandHandlerDelegate next,
        CancellationToken ct)
    {
        // Log before/after
        await next();
    }
}