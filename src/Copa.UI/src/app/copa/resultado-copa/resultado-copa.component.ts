import { Component, OnInit } from '@angular/core';
import { CopaService } from '../copa.service';
import { Copa } from '../copa';

@Component({
  selector: 'app-resultado-copa',
  templateUrl: './resultado-copa.component.html',
  styleUrls: ['./resultado-copa.component.css']
})
export class ResultadoCopaComponent implements OnInit {

  constructor(private copaService: CopaService) { }
  public copa: Copa;
  ngOnInit() {
    this.copaService.obterCopa()
    .subscribe(
      cop => {
        this.copa = cop;
        console.log(cop);
      },
      error => console.log(error)
    );
  }

}
