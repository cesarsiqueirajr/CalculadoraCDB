import { Component } from '@angular/core';
import { CalculoCdbService } from './calculo-cdb.service';

@Component({
  selector: 'app-calculo-cdb',
  templateUrl: './calculo-cdb.component.html',
  styleUrls: ['./calculo-cdb.component.css']
})
export class CalculoCdbComponent {
  valor!: number;
  prazo!: number;
  resultadoBruto: number | null = null;
  resultadoLiquido: number | null = null;

  constructor(private calculoCdbService: CalculoCdbService) { }

  calcularInvestimento() {
    this.calculoCdbService.calcularInvestimento(this.valor, this.prazo)
      .subscribe(resultados => {
        this.resultadoBruto = resultados.resultadoBruto;
        this.resultadoLiquido = resultados.resultadoLiquido;
      });
  }
}
