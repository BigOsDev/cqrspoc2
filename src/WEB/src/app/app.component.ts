import { Component } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { HubConnection, HubConnectionBuilder,HttpTransportType,LogLevel} from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'app';

  private hubConnection: HubConnection;
  private gridApi;  
  private gridColumnApi;
  private getRowNodeId;
  private gridOptions;

  constructor(private http: HttpClient) {

  }

  columnDefs = [
      {headerName: 'Id', field: 'id', editable: true },
      {headerName: 'Title', field: 'title', editable: true },
      {headerName: 'Description', field: 'description', editable: true},
      {headerName: 'Added', field: 'added', editable: true},
      {headerName: 'Price', field: 'price', editable: true},
      {headerName: 'Rate', field: 'rate', editable: true},
      {headerName: 'Votes', field: 'votes', editable: true},
      {headerName: 'Restaurant Name', field: 'restaurantName', editable: true},
      {headerName: 'Another', field: 'another1', editable: true},
      {headerName: 'Another', field: 'another2', editable: true},
      {headerName: 'Another', field: 'another3', editable: true},
      {headerName: 'Another', field: 'another4', editable: true}
  ];



  rowData: any;
  //  [
  //     { make: 'Toyota', model: 'Celica', price: 35000, name: 'Olivia Brennan', country: 'Poland', another1: 'Sugoroku' , another2: 'Shogi' , another3: 'Checkers' , another4: 'Ghosts' },
  //     { make: 'Ford', model: 'Mondeo', price: 32000, name: 'Mia Corbin', country: 'Sweden', another1: 'Patolli' , another2: 'Shogi' , another3: 'Shogi' , another4: 'Camelot'  },
  //     { make: 'Porsche', model: 'Boxter', price: 8000, name: 'Isla Fletcher', country: 'France', another1: 'Shogi' , another2: 'Shogi' , another3: 'Camelot' , another4: 'Patolli'  } ,     
  //     { make: 'Toyota', model: 'Celica', price: 35000, name: 'Olivia Brennan', country: 'Poland', another1: 'Sugoroku' , another2: 'Shogi' , another3: 'Checkers' , another4: 'Ghosts' },
  //     { make: 'Checkers', model: 'Bul', price: 98280, name: 'Mia Corbin', country: 'Sweden', another1: 'Patolli' , another2: 'Shogi' , another3: 'Shogi' , another4: 'Camelot'  },
  //     { make: 'Tablut', model: 'Gipf', price: 12400, name: 'Isla Fletcher', country: 'France', another1: 'Shogi' , another2: 'Shogi' , another3: 'Camelot' , another4: 'Patolli'  },
  //     { make: 'Toyota', model: 'Wari', price: 92000, name: 'Olivia Brennan', country: 'Poland', another1: 'Sugoroku' , another2: 'Shogi' , another3: 'Checkers' , another4: 'Ghosts' },
  //     { make: 'Master Mind', model: 'PUNCT', price: 72000, name: 'Mia Corbin', country: 'Sweden', another1: 'Patolli' , another2: 'Shogi' , another3: 'Shogi' , another4: 'Camelot'  },
  //     { make: 'Kalah', model: 'Boxter', price: 49000, name: 'Isla Fletcher', country: 'France', another1: 'Shogi' , another2: 'Shogi' , another3: 'Camelot' , another4: 'Patolli'  } ,   
  //       { make: 'Toyota', model: 'Celica', price: 35000, name: 'Olivia Brennan', country: 'Poland', another1: 'Sugoroku' , another2: 'Shogi' , another3: 'Checkers' , another4: 'Ghosts' },
  //     { make: 'Ford', model: 'Mondeo', price: 67080, name: 'Mia Corbin', country: 'Sweden', another1: 'Patolli' , another2: 'Shogi' , another3: 'Shogi' , another4: 'Camelot'  },
  //     { make: 'Sugoroku', model: 'Boxter', price: 79400, name: 'Isla Fletcher', country: 'France', another1: 'Shogi' , another2: 'Shogi' , another3: 'Camelot' , another4: 'Patolli'  }
  // ];

  ngOnInit() {
    this.http.get('https://localhost:5001/api').subscribe(data=>
     this.rowData =  (data as any).result
     );

     let builder = new HubConnectionBuilder();
     
     this.hubConnection = builder.configureLogging(LogLevel.Debug).withUrl('https://localhost:5001/eventNotifications', {skipNegotiation: true,  transport: HttpTransportType.WebSockets}).build();  // see startup.cs
     this.hubConnection.on('SendNotification', (message) => {
     
    for(let i = 0; i < this.rowData.length; i++)
      {
        if(this.rowData[i].id === message.agregateId)
        {         
            var rowNode = this.gridApi.getRowNode(message.agregateId);
            rowNode.setDataValue(this.deCapitalize(message.data.propertyName), message.data.newValue);
            console.log(rowNode);
        }
      }
       console.log(message);
     });
     this.hubConnection.start();

     this.getRowNodeId = function(data) {
      return data.id;
    };
  }

  

  capitalize = (s) => {
    if (typeof s !== 'string') return ''
    return s.charAt(0).toUpperCase() + s.slice(1)
  }

  deCapitalize = (s) => {
    if (typeof s !== 'string') return ''
    return s.charAt(0).toLowerCase() + s.slice(1)
  }

  

  onCellValueChanged(params) {
    console.log(params);

    const headers = new HttpHeaders();
    headers.set('Content-Type', 'application/json; charset=utf-8');

    if(params.oldValue !== params.newValue)
    {
    var request = {
      agregateId:params.data.id,
      propertyName:  this.capitalize(params.colDef.field),
      oldValue:params.oldValue,
      newValue: params.newValue
    }
    this.http.post('https://localhost:5001/api',request,{ headers: headers}).subscribe(
      data  => {
      console.log("POST Request is successful ", data);
      },
      error  => {
      //todo: add message
      //infinite loop - fix it
    //  var rowNode = this.gridApi.getRowNode(params.data.id);
    //  rowNode.setDataValue(params.colDef.field,params.oldValue);
      console.log("Error", error);
      
      });
    }
  }

  onGridReady(params) {
    this.gridApi = params.api;
    this.gridColumnApi = params.columnApi;
  }
  
}
