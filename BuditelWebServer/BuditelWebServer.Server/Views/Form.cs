using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuditelWebServer.Server.Views
{
	public static class Form
	{
		public const string Html = @"<!doctype html>
<html lang=""bg"">
<head>
  <meta charset=""utf-8"">
  <meta name=""viewport"" content=""width=device-width,initial-scale=1"">
  <title>Проста форма</title>

  <style>
    body{
      margin:0;
      height:100vh;
      display:flex;
      align-items:center;
      justify-content:center;
      font-family: system-ui, sans-serif;
      background:#f4f6f8;
    }

    form{
      background:white;
      padding:24px;
      border-radius:10px;
      box-shadow:0 8px 20px rgba(0,0,0,.08);
      width:280px;
      display:flex;
      flex-direction:column;
      gap:12px;
    }

    h2{
      margin:0 0 8px 0;
      text-align:center;
    }

    input{
      padding:8px 10px;
      border-radius:6px;
      border:1px solid #ccc;
      font-size:14px;
    }

    input:focus{
      outline:none;
      border-color:#4a90e2;
    }

    button{
      margin-top:6px;
      padding:9px;
      border:none;
      border-radius:6px;
      background:#4a90e2;
      color:white;
      font-size:14px;
      cursor:pointer;
    }

    button:hover{
      background:#3a78c2;
    }
  </style>
</head>

<body>

  <form action=""/login"" method=""post"">
    <h2>Регистрация</h2>

    <input 
      type=""text"" 
      name=""name"" 
      placeholder=""Име"" 
      required
    >

    <input 
      type=""number"" 
      name=""age"" 
      placeholder=""Възраст""
      min=""1""
      max=""120""
      required
    >

    <button type=""submit"">Изпрати</button>
  </form>

</body>
</html>
"; 
	}
}
