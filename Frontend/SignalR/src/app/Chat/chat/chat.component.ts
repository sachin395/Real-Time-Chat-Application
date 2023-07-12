import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ChatService } from '../chat.service';
import { MessageDto } from 'src/app/Model/message-dto';
import jsPDF from 'jspdf';




@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
 

  constructor(private chatService: ChatService) {
    this.chatService.GetChats(0).subscribe(res=>{
      this.msgArr=res
      console.log(this.msgArr)
    })     
  }

  ngOnInit(): void {
    this.chatService.retrieveMappedObject().subscribe( (receivedObj: MessageDto) => { this.addToInbox(receivedObj) ;console.log(receivedObj)});  // calls the service method to get the new messages sent
                                                     
  }
  name = 'Angular 5';
  fileUrl:any;
  msgDto: MessageDto = new MessageDto();
  msgInboxArray: MessageDto[] = [];
  msgArr:MessageDto[]=[]
  
  send(): void {
    if(this.msgDto) {
      if(this.msgDto.user.length == 0 || this.msgDto.user.length == 0){
        window.alert("Both fields are required.");
        return;
      } else {
        this.chatService.broadcastMessage(this.msgDto);  
               
      }
      
    }
  }

  addToInbox(obj: MessageDto) {
    let newObj = new MessageDto();
    newObj.user = obj.user;
    newObj.msgText = obj.msgText;
    newObj.Date=obj.Date;
    console.log(obj.Date)
    this.msgInboxArray.push(newObj);

  }
  // @ViewChild('pdfContent', { static: false }) pdfContent!: ElementRef;
  // generatePDF() {
  //   const content = this.pdfContent.nativeElement.innerHTML;
  //   const doc = new jsPDF();

  //   doc.html(content, {
  //     callback: () => {
  //       doc.save('your_file_name.pdf');
  //     }
  //   });
  // }
  

}




