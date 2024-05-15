import { NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-advertisement-edit',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, NgIf],
  templateUrl: './advertisement-edit.component.html',
  styleUrl: './advertisement-edit.component.css'
})
export class AdvertisementEditComponent implements OnInit {

  editMode = false;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.editMode = params['id'] != null;
    });
  }

  onSubmit() {
    console.log('Form submitted!');
  }

}
