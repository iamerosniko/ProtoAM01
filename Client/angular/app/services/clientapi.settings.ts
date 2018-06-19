export class ClientApiSettings {

    //change the url according to client's url
    private static CLIENT_URL = "app/"
    
    public static GETBWURL(controller:string):string{
        var BW_URL = localStorage.getItem("BWAPI");
        return BW_URL+controller;
    }

    //use this method when callin an client apis
    public static GETCLIENTAPIURL(controller:string):string{
        return this.CLIENT_URL+controller;
    }

    public static HANDLEERROR(error : any):Promise<any>{
        console.error('An error occured',error);
        return Promise.reject(error.message || error);
    }
}
