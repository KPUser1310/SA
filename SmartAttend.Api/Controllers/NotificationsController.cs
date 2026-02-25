using Microsoft.AspNetCore.Mvc;
using SmartAttend.Application.Notifications.Queries;
using SmartAttend.Application.Notifications.Commands;
using SmartAttend.Application.Notifications;
using SmartAttend.Application.Common.DTOs;
using SmartAttend.Application.Notifications.DTOs;

namespace SmartAttend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ApiControllerBase
    {
        public NotificationsController() { }

        [HttpGet]
        [ProducesResponseType(typeof(OperatorDashBoardResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("OperatorNotificationList/{accountId}")]
        public async Task<IActionResult> GetOperatorNotificationList(int accountId, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetOperatorNotificationListByIdQuery { AccountId = accountId }, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("NotificationRead/{notificationId}")]
        public async Task<IActionResult> NotificationRead(int notificationId,CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new NotificationReadCommand { NotificationId = notificationId }, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("NotificationOff")]
        public async Task<IActionResult> NotificationOff(NotificationOffCommand notificationOffRequest, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(notificationOffRequest, cancellationToken);
            return Ok(result);
        }


        [HttpGet]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("NotificationCount/{accountId}")]
        public async Task<IActionResult> NotificationCount(int accountId, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetLayoutNotifyCountQuery { AccountId = accountId }, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(NotificationDeviceResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("NotificationCountByDeviceId/{accountId}")]
        public async Task<IActionResult> NotificationCountByDeviceId(int accountId, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetNotificationCountbyDeviceIdQuery { AccountId = accountId }, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PageResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateAllNotification/{accountId}")] //ReadAllNotification API Name is changed to UpdateAllNotification
        public async Task<IActionResult> UpdateAllNotificationNotification(int accountId, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new UpdateAllNotificationListCommand { AccountId = accountId }, cancellationToken);
            return Ok(result);
        }

    }
}
