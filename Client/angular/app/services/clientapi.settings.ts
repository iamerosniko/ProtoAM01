export class ClientApiSettings {

    //change the url according to client's url
    private static CURRENT_URL = "http://localhost:50000/api/"
    //change the url according for business workflow urls
    private static BW_URL = "http://localhost:49475/api/"
    //  private static BW_URL = "http://btaccessmanagementbw-dev.azurewebsites.net/api/"
    // private static BW_URL = "http://btamdev.azurewebsites.net/api/"

    //Use this Method when calling an business_workflow apis
    public static GETBWURL(controller:string):string{
        return this.BW_URL+controller;
    }

    //use this method when callin an client apis
    public static GETCLIENTAPIURL(controller:string):string{
        return this.CURRENT_URL+controller;
    }

    public static HANDLEERROR(error : any):Promise<any>{
        console.error('An error occured',error);
        return Promise.reject(error.message || error);
    }
}
