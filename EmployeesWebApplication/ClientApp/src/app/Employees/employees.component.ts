import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})
export class EmployeesComponent {
  public employees: Employee[];
  public employee_id: number;

  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.search_employees();
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
