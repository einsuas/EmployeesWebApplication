import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})
export class EmployeesComponent {
  public employees: Employee[];
  public employee_id: number;

  public selected_employee: Employee;

  confirmation_answer: boolean;
  show_confirmation_view: boolean;
  message: string;
  pending_confirmation_action: string;
  pending_object: any;

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

  select_employee(selected_employee: Employee) {

    this.selected_employee = JSON.parse(JSON.stringify(selected_employee));
  }

  fire(employee: Employee, confirmed = false) {
    if (confirmed) {
      this.confirmation_answer = undefined;
    }
    else {
      this.show_confirmation_view = true;
      this.pending_object = employee;
      this.pending_confirmation_action = 'fire_employee';
      this.message = 'Do you want to fire the current employee?';
    }
  }
}

interface Employee {
  id: number;
  name: string;
  contractTypeName: string;
  roleId: number;
  roleName: string;
  roleDescription: string;
  hourlySalary: number;
  monthlySalary: number;
  annualSalary: number;
}
