import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from 'src/components/header/header.component';
import { FooterComponent } from 'src/components/footer/footer.component';
import { HomeComponent } from 'src/components/home/home.component';
import { SidebarComponent } from 'src/components/sidebar/sidebar.component';
import { MainComponent } from 'src/components/main/main.component';
import { AdvogadoCadastroComponent } from 'src/components/advogado/cadastro/cadastro.component';
import { AdvogadoConsultaComponent } from 'src/components/advogado/consulta/consulta.component';
import { CadastroClienteComponent } from 'src/components/cliente/cadastro/cadastro.component';
import { AlertComponent } from 'src/components/alert/alert.component';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    AlertComponent,
    HeaderComponent,
    SidebarComponent,
    HomeComponent,
    FooterComponent,
    AdvogadoCadastroComponent,
    AdvogadoConsultaComponent,
    CadastroClienteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
