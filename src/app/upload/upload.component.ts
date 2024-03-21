import { Component, EventEmitter, Output } from '@angular/core'
import { HttpClient, HttpEventType } from '@angular/common/http'

@Component({
    selector: 'app-upload',
    templateUrl: './upload.component.html',
    styleUrls: ['./upload.component.css']
})

export class UploadComponent {

    public message: string
    public progress: number

    @Output() public onUploadFinished = new EventEmitter()

    constructor(private httpClient: HttpClient) { }

    public uploadSelectedFile = (files: any): void => {
        if (files.length == 0) {
            return
        }
        const fileToUpload = <File>files[0]
        const formData = new FormData()
        formData.append('file', fileToUpload, fileToUpload.name)
        this.httpClient.post('https://localhost:5001/api/upload', formData, { reportProgress: true, observe: 'events' }).subscribe(event => {
            if (event.type == HttpEventType.UploadProgress) {
                this.progress = Math.round(100 * event.loaded / event.total)
            } else if (event.type == HttpEventType.Response) {
                this.message = 'Success!'
                this.onUploadFinished.emit(event.body)
            }
        })
    }

}
