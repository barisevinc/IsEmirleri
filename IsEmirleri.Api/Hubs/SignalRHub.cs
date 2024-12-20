﻿using IsEmirleri.Business.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace IsEmirleri.Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;
        private readonly IMissionService _missionService;
        private readonly IProjectService _projectService;
        public SignalRHub(INotificationService notificationService, IUserService userService, IMissionService missionService, IProjectService projectService)
        {
            _notificationService = notificationService;
            _userService = userService;
            _missionService = missionService;
            _projectService = projectService;
        }

        public async Task SendNotification(int id)
        {
            var value = _notificationService.NotificationWithNotRead(id);
            await Clients.All.SendAsync("NotificationCount", value);
            var notificationList = _notificationService.GetAllNotification(id);
            await Clients.All.SendAsync("NotificationList", notificationList);

        }
        public async Task GetUserInformationCounts(int userId)
        {
            var customerValue = _missionService.GetCustomerInformationCounts(userId);
            await Clients.All.SendAsync("CustomerInformationCounts", customerValue);
            var userValue = _missionService.GetUserInformationCounts(userId);
            await Clients.All.SendAsync("UserInformationCounts", userValue);
        }
        public async Task GetProjectCount(int customerId)
        {
            var projectValue= _projectService.ProjectCount(customerId);
            await Clients.All.SendAsync("ProjectCount", projectValue);
        }
    }
}
