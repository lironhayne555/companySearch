<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Company.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js" integrity="sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN" crossorigin="anonymous"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.3/jquery.min.js"></script>
    <script src="JS/main.js"></script>
</head>
<body>
    <h3 class="text-decoration-underline text-center mt-5">Company Search</h3>
    <div class="container mt-3">
        <div class="container mb-3">
        <label class="form-label" for="company">Company Name:</label>
        <input class="form-control" name="company" type="text" id="company"/>
        <div class="radioOP">
            <label class="form-check-label" for="searchByComp">Equal</label>
            <input class="searchByComp form-check-input" name="searchByComp" type="radio" value="="/>
            <label class="form-check-label" for="searchByComp">Start With</label>
            <input class="searchByComp form-check-input" name="searchByComp" type="radio" value="START"/>
            <label class="form-check-label" for="searchByComp">End With</label>
            <input class="searchByComp form-check-input" name="searchByComp" type="radio" value="END"/>
            <label class="form-check-label" for="searchByComp">Middle</label>
            <input class="searchByComp form-check-input" name="searchByComp" type="radio" value="MID"/>
        </div>
        </div>
        <div class="container mb-3" >
        <label class="form-label" for="name">Contact Name:</label>
        <input class="form-control" name="name" type="text" id="name"/>
        <div class="radioOP">
            <label class="form-check-label" for="serachByName">Equal</label>
            <input class="serachByName form-check-input" name="serachByName" type="radio" value="="/>
            <label for="serachByName">Start With</label>
            <input class="serachByName form-check-input" name="serachByName" type="radio" value="START"/>
            <label class="form-check-label" for="serachByName">End With</label>
            <input class="serachByName form-check-input" name="serachByName" type="radio" value="END"/>
            <label class="form-check-label" for="serachByName">Middle</label>
            <input class="serachByName form-check-input" name="serachByName" type="radio" value="MID"/>
        </div>
        </div>
        <div class="container mb-3 form-check">
            <label class="form-label" for="phone">Phone:</label>
            <input class="form-control"  id="phone" type="text" name="phone"/>
        </div>
        <button id="myBtn" class="btn btn-info" onclick="CheckData()">Search</button>
        <button id="newBtn" style="display:none" onclick="NewSearch()" type="button" class="btn btn-outline-warning">New Search</button>
    </div>
</body>
</html>
