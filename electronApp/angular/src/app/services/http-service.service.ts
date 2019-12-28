import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http'

const baseUrl = 'https://www.easy-mock.com/mock/5dffad60927ae21dbdbee16b/example/'

@Injectable({
  providedIn: 'root'
})

export class HttpServiceService {

  constructor(private http:HttpClient) { }
  public anyList:any
  getData(){
    let url = baseUrl
    this.http.get(url).subscribe((res: any)=>{

      console.log("GET 请求", res)
      this.anyList = res
      // this.newsList = res.data.relateQuery
      alert(this.anyList)

    })
  }
}
