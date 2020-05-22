<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Eliminar</title>
</head>
<body>
  <h1>
    <form method="post" action="EliminarRegistro">
        <table>
            <tr>
                <td>Video Id</td>
                <td><input type="text" name="idVideo" /></td>
             </tr>
             <tr>
                <td colspan="2"><input type="submit" value="Borrar registro"/></td>
             </tr>
        </table>
    </form>
    </h1>
</body>
</html>
