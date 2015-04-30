<!DOCTYPE html>
<html ng-app="app">
<head>
    <title></title>
    <script src="Scripts/jquery-2.1.1.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.0.8/angular.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/app.js"></script>
    <script src="Scripts/xeditable.js"></script>
    <script src="Scripts/angular-mocks.js"></script>
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="CSS/xeditable.css" rel="stylesheet" />
    <script src="Scripts/angular.min.js"></script>
    <style>
        /*div[ng-app]
        {
            margin: 10px;
        }

        form[name="editableForm"] > div
        {
            height: auto;
            padding: 5px 0;
        }

        form[name="editableForm"] .title
        {
            display: inline-block;
            font-weight: bold;
            padding-top: 5px;
            vertical-align: top;
            min-width: 90px;
        }

        form[name="editableForm"] .editable
        {
            display: inline-block;
            padding-top: 5px;
            vertical-align: top;
        }

        form[name="editableForm"] select
        {
            width: 120px;
        }*/

            /*Styling for the edit-in-place form on the tickets*/
    div[ng-app]
    {
        margin: 15px;
    }

    form[name="editableForm"] > div
    {
        height: auto;
        padding: 5px 0;
    }

    form[name="editableForm"] .title
    {
        display: inline-block;
        font-weight: bold;
        padding-top: 5px;
        vertical-align: top;
        min-width: 90px;
    }

    form[name="editableForm"] .editable
    {
        display: inline-block;
        padding-top: 5px;
        vertical-align: top;
    }

    form[name="editableForm"] select
    {
        width: 120px;
    }
    </style>
</head>

<body>
<h4>Angular-xeditable Editable form (Bootstrap 3)</h4>
<%--<div ng-app="app" ng-controller="Ctrl">
 <form editable-form name="editableForm" onaftersave="saveUser()">
    <div>
      <!-- editable username (text with validation) -->
      <span class="title">User name: </span>
      <span editable-text="user.name" e-name="name" onbeforesave="checkName($data)" e-required>{{ user.name || 'empty' }}</span>
    </div> 

    <div>
      <!-- editable status (select-local) -->
      <span class="title">Status: </span>
      <span editable-select="user.status" e-name="status" e-ng-options="s.value as s.text for s in statuses">
        {{ (statuses | filter:{value: user.status})[0].text || 'Not set' }}
      </span>
    </div>  

    <div>
      <!-- editable group (select-remote) -->
      <span class="title">Group: </span>
      <span editable-select="user.group" e-name="group" onshow="loadGroups()" e-ng-options="g.id as g.text for g in groups">
        {{ showGroup() }}
      </span>
    </div>

    <div>
      <!-- button to show form -->
      <button type="button" class="btn btn-default" ng-click="editableForm.$show()" ng-show="!editableForm.$visible">
        Edit
      </button>
      <!-- buttons to submit / cancel form -->
      <span ng-show="editableForm.$visible">
        <button type="submit" class="btn btn-primary" ng-disabled="editableForm.$waiting">
          Save
        </button>
        <button type="button" class="btn btn-default" ng-disabled="editableForm.$waiting" ng-click="editableForm.$cancel()">
          Cancel
        </button>
      </span>
    </div>
  </form>  
</div>--%>
    <div ng-app="app">
        <form editable-form name="editableForm" onaftersave="saveUser()">
            <div>
                <!-- editable title (text with validation) -->
                <span editable-text="ticket.title" e-name="title" e-required><strong style="font-size: 26px; color: black;">{{ ticket.title || 'empty' }}</strong></span>
            </div>

            <div>
                <!-- editable description (text with validation) -->
                <span editable-text="ticket.description" e-name="description" e-required><strong style="font-size: 18px; color: black;">{{ ticket.description || 'empty' }}</strong></span>
            </div>

            <div>
                <!-- button to show form -->
                <button type="button" class="btn btn-default" ng-click="editableForm.$show()" ng-show="!editableForm.$visible">
                    Edit
                </button>
                <!-- buttons to submit / cancel form -->
                <span ng-show="editableForm.$visible">
                    <button type="submit" class="btn btn-primary" ng-disabled="editableForm.$waiting">
                        Save
                    </button>
                    <button type="button" class="btn btn-default" ng-disabled="editableForm.$waiting" ng-click="editableForm.$cancel()">
                        Cancel
                    </button>
                </span>
            </div>
        </form>
    </div>
</body>
</html>
