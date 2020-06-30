import { Component, OnInit } from '@angular/core';
import { EquipeService } from '../equipe.service';
import { Equipe } from '../equipe';
import { Router } from '@angular/router';

@Component({
  selector: 'app-listar-equipe',
  templateUrl: './listar-equipe.component.html'
})

export class ListarEquipeComponent implements OnInit {

  constructor(private equipeService: EquipeService, private router: Router) { }

  public qtdEquipesSelect = 0;
  public equipes: Equipe[];

  ngOnInit() {
    this.equipeService.obterEquipes()
      .subscribe(
        equ => {
          this.equipes = equ;
          console.log(equ);
        },
        error => console.log(error)
      );
  }
  checkValue(values:any){
    if ( values) 
    {
      this.qtdEquipesSelect++;
    }else{
      if(this.qtdEquipesSelect > 0)
      {
        this.qtdEquipesSelect--;
      }
    }
  }

   isSelected(value) {
    return value.isChecked;
  }

  onClickRealizarCopa()
  {
    //filtrar as equipes selecionadas
    var EquipesSelecionadas = this.equipes.filter(this.isSelected);
    //adcionar no storage
    localStorage.removeItem("equipes");
    localStorage.setItem("equipes",JSON.stringify(EquipesSelecionadas));
    // chama o próximo component
    this.router.navigate(['copa'])

  }



}
