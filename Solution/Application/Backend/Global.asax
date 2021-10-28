<%@ Application Language="C#" %>  
<script runat="server">  
    void Session_Start(object sender, EventArgs e)  
    {  
        var sessionID = Session.SessionID;
        Console.WirteLine("somthing right here 12345679 somthing right here 12345679 somthing right here 12345679 somthing right here 12345679 somthing right here 12345679 somthing right here 12345679 somthing right here 12345679")
    }  
    void Session_End(object sender, EventArgs e)  
    {  
        var databaseContext = DependencyResolver.Current.GetService<DatabaseContext>();  
        var sessionContext = DependencyResolver.Current.GetService<SessionContext>();
        string token = sessionContext.getToken("token");
        SmartLock.Models.User.User user = await databaseContext.Set<SmartLock.Models.User.User>()
            .FirstOrDefaultAsync(x => x.ActivToken == token);
        if(user != default)
        {
            user.ActivToken = "";
            databaseContext.SaveChanges();
            sessionContext.RemoveToken("token");
            return true;
        }
    }  
</script>