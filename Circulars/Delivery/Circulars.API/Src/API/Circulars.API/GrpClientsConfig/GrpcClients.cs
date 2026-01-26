//using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using Circulars.Application.Protos;

namespace Circulars.API.GrpClientsConfig
{

    public static class GrpcClients
    {
        #region UserManagement
        public static void AddUserManagementGrpcClients(
            this IServiceCollection services,
            string UserManagmentUrl)
        {
            services.AddGrpcServiceClient<PermissionGroupingService.PermissionGroupingServiceClient>(UserManagmentUrl);
            services.AddGrpcServiceClient<UserProtoService.UserProtoServiceClient>(UserManagmentUrl);
        }
        #endregion

        #region ControlPanel.Aggregator
        public static void AddCPAggregatorGrpcClients(this IServiceCollection services, string url)
        {
            services.AddGrpcServiceClient<OrgProtoService.OrgProtoServiceClient>(url);
            services.AddGrpcServiceClient<OrgMembersProtoService.OrgMembersProtoServiceClient>(url);

        }
        #endregion

    }
}
