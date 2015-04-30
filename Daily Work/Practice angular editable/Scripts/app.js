var app = angular.module("app", ["xeditable", "ngMockE2E"]);

app.run(function (editableOptions) {
    editableOptions.theme = 'bs3';
});

app.controller('Ctrl', function ($scope, ticketFactory, notificationFactory) {
    $scope.tickets = [];
    $scope.addMode = false;
    $scope.toggleAddMode = function () { $scope.addMode = !$scope.addMode; };
    $scope.toggleEditMode = function (ticket) { ticket.editMode = !ticket.editMode; };

    var getTicketsSuccessCallback = function (data, status) { $scope.tickets = data; };
    var errorCallback = function (data, status, headers, config) { notificationFactory.error(data.ExceptionMessage); };
    var successCallback = function (data, status, headers, config) {
        notificationFactory.success();
        return ticketFactory.getTickets().success(getTicketsSuccessCallback).error(errorCallback);
    };

    var successPostCallback = function (data, status, headers, config) {
        successCallback(data, status, headers, config).success(function () {
            $scope.toggleAddMode();
            $scope.ticket = {};
        });
    };

    ticketFactory.getTickets().success(getTicketsSuccessCallback).error(errorCallback);

    $scope.addTicket = function () { ticketFactory.addTicket($scope.ticket).success(successPostCallback).error(errorCallback); };
    $scope.deleteTicket = function (ticket) { ticketFactory.deleteTicket(ticket).success(successCallback).error(errorCallback); };
    $scope.updateTicket = function (ticket) { ticketFactory.updateTicket(ticket).success(successCallback).error(errorCallback); };

    $scope.saveUser = function () {
        // $scope.user already updated!
        return $http.post('/saveUser', $scope.user).error(function (err) {
            if (err.field && err.msg) {
                // err like {field: "name", msg: "Server-side error for this username!"} 
                $scope.editableForm.$setError(err.field, err.msg);
            } else {
                // unknown error
                $scope.editableForm.$setError('name', 'Unknown error!');
            }
        });
    };
});