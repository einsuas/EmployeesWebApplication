import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})
export class EmployeesComponent {
  public employees: Employee[];
  public employee_id: number;


  //Confirmation Dialog
  confirmation_answer: boolean;
  show_confirmation_view: boolean;
  message: string;
  pending_confirmation_action: string;
  pending_object: any;

  //Employee Dialog
  show_employee_dialog: boolean;
  selected_employee: Employee;
  update_list: boolean;

  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.search_employees();
  }

  ngDoCheck() {
    if (this.confirmation_answer != undefined) {
        if (this.confirmation_answer) {
          switch (this.pending_confirmation_action) {
          case 'fire_employee':
              {
                this.fire(this.pending_object, true);
                break;
              }
          }
        }
        else {
          this.pending_confirmation_action = "";
          this.confirmation_answer = undefined;
        }
    }
    if (this.update_list) {
      this.update_list = false;
      this.save_employee();
    }
  }

  search_employees() {
    var url = this.baseUrl + 'employees';
    if (this.employee_id) {
      let params = new HttpParams().set('employeeId', this.employee_id.toString());
      this.http.get<Employee[]>(url, { params: params }).subscribe(result => {
        this.employees = result;
      }, error => alert(error));
    } else {
      this.http.get<Employee[]>(url).subscribe(result => {
        this.employees = result;
      }, error => alert(error));
    }
  }

  save_employee() {
    var url = this.baseUrl + 'employees/UpdateEmployee';
    let params = new HttpParams().set('employee', this.selected_employee.toString());
    this.http.post<any>(url, JSON.stringify(this.selected_employee)).subscribe(result => {
      if (result) {
        const position = this.employees.findIndex(((employeeEl: Employee) => {
          return employeeEl.Id === this.selected_employee.Id;
        }) as any);
        this.employees[position] = this.selected_employee;
      }
    }, error => alert(error));
  }

  fire_employee(employee_id: number) {
    var url = this.baseUrl + 'employees';
    let params = new HttpParams().set('employeeId', employee_id.toString());
    this.http.delete<any>(url, { params: params }).subscribe(result => {
      if (result) {
        this.employees = this.employees.filter(e => e.Id !== employee_id);
      }
    }, error => alert(error));
  }

  select_employee(selected_employee: Employee) {
    this.selected_employee = JSON.parse(JSON.stringify(selected_employee));
    this.show_employee_dialog = true;
  }

  fire(employee: Employee, confirmed = false) {
    if (confirmed) {
      this.confirmation_answer = undefined;
      this.fire_employee(employee.Id);
    }
    else {
      this.show_confirmation_view = true;
      this.pending_object = employee;
      this.pending_confirmation_action = 'fire_employee';
      this.message = 'Do you want to fire the current employee?';
    }
  }
}
