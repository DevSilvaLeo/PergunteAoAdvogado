import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdvogadoCadastroComponent } from 'src/components/advogado/cadastro/cadastro.component';
import { CadastroClienteComponent } from 'src/components/cliente/cadastro/cadastro.component';
import { MainComponent } from 'src/components/main/main.component';


const routes: Routes = [
  {path: '', redirectTo:'/main', pathMatch:'full'},
  {path:'main', component: MainComponent},
  {path:'cadastro-advogado', component: AdvogadoCadastroComponent},
  {path:'cadastro-cliente', component: CadastroClienteComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
