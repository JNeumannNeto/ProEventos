import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

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
      titulo: ['',
          [
            Validators.required
          ]
      ],
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
      telefone: ['',
        [
          Validators.required
        ]
      ],
      funcao: ['',
        [
          Validators.required
        ]
      ],
      descricao: ['',
        [
          Validators.required
        ]
      ],
      senha: ['',
        [
          Validators.nullValidator,
          Validators.minLength(8),
          Validators.maxLength(20)
        ]
      ],
      confirma: ['', Validators.nullValidator ]
    },
    formOptions);
  }

  public resetForm(event: any): void{
    event.preventDefault();
    this.form.reset();
  }
}

