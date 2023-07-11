import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/models/employees.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {

  addEmployee: Employee = {
    id: '',
    name: '',
    email: '',
    phone: 0,
    salary: 0,
    departament: ''
  }
  constructor(private route: ActivatedRoute, private employeeService: EmployeesService, private router: Router) { }

  ngOnInit(): void {
  }

  addEmployees()
  {
    this.employeeService.addEmployee(this.addEmployee).subscribe({
      next: (employee) =>{
        this.router.navigate(['employees']);
      }
    });
  }

}
