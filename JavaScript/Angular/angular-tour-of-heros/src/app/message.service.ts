import { Injectable } from '@angular/core'; 

@Injectable()
export class MessageService {

  messages: string[] = [];

  add(message: string) {
    //if (this.messages == null) this.messages =string[] = [];
    this.messages.push(message);
  }

  clear() { this.messages = []; }

}
