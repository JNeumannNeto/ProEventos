import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  form: FormGroup;

  ngOnInit(): void{}

  get f(): any{
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('senha', 'confirma')
    };

    this.form = this.fb.group({
      nome: ['',
          [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(20)
          ]
      ],
      sobrenome: ['',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(50)
        ]
      ],
      email: ['',
        [
          Validators.required,
          Validators.email
        ]
      ],
      usuario: ['',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(20)
        ]
      ],
      senha: ['',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.maxLength(20)
        ]
      ],
      confirma: ['', Validators.required ]
    },
    formOptions);
  }

  public resetForm(): void{
    this.form.reset();
  }
}
