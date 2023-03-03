import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss']
})
export class EventoDetalheComponent implements OnInit {

  form: FormGroup;

  get f(): any{
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      tema: ['',
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(50)
          ]
      ],
      local: ['',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(50)
        ]
      ],
      dataEvento: ['', Validators.required ],
      qtdPessoas: ['',
        [
          Validators.required,
          Validators.max(500)
        ]
      ],
      imagemURL: ['', Validators.required ],
      telefone: ['', Validators.required ],
      email: ['',
        [
          Validators.required,
          Validators.email
        ]
      ]
    });
  }

  ngOnInit(): void{
    //this.validation();
  }

  public resetForm(): void{
    this.form.reset();
  }

  /*public validation(): void{
    this.form = this.fb.group({
        local: ['',
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(50)
          ]
        ],
        dataEvento: ['', Validators.required ],
        tema: ['',
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(50)
          ]
        ],
        qtdPessoas: ['',
          [
            Validators.required,
            Validators.max(500)
          ]
        ],
        imagemURL: ['', Validators.required ],
        telefone: ['', Validators.required ],
        email: ['',
          [
            Validators.required,
            Validators.email
          ]
        ]
      }
    )
  }*/
}
