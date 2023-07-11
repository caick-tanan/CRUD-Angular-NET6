import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Employee } from '../models/employees.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  baseApiUrl: string = environment.baseApiUrl;
constructor(private htttp: HttpClient) { }

  getAllEmployess(): Observable<Employee[]>
  {
    return this.htttp.get<Employee[]>(this.baseApiUrl + '/api/employees');
  }

  addEmployee(addEmployee: Employee): Observable<Employee>{
    addEmployee.id = '00000000-0000-0000-0000-000000000000';
    return this.htttp.post<Employee>(this.baseApiUrl + '/api/employees', addEmployee);
  }

  getEmployee(id: string): Observable<Employee>{
    return this.htttp.get<Employee>(this.baseApiUrl + '/api/employees/'+id);
  }

  updateEmployee(id: string, updateEmployeeRequest: Employee): Observable<Employee> {
    return this.htttp.put<Employee>(this.baseApiUrl + '/api/employees/'+id, updateEmployeeRequest);
  }

  deleteEmployee(id: string): Observable<Employee> {
    return this.htttp.delete<Employee>(this.baseApiUrl + '/api/employees/'+id);
  }

}
