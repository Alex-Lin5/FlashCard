import { Component, OnInit } from '@angular/core';
import { Cards } from './cards.model';
import { CardsService } from './cards.service';
import { FormGroup, FormControl, FormBuilder} from '@angular/forms'
import { RouterLink, RouterLinkActive } from '@angular/router';
@Component({
  selector: 'app-cards',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './cards.component.html',
  styleUrl: './cards.component.css'
})
export class CardsComponent implements OnInit{
  adding:boolean = false;
  editing:boolean = false;
  deleting:boolean = false;
  view:string = 'table';
  formAdd:FormGroup = this.creatForm();
  formEdit = this.creatForm();
  cards:Cards[] = [];
  cardValue: Cards={
    cardId:'',
    question:'',
    answer:'',
    status:''
  };
  cardEdit:Cards = this.cardValue;
  constructor(
    private cardsService:CardsService,
    private formBuilder:FormBuilder){}

  ngOnInit(): void {
    this.getAllCards();
  }
  ngOnDestroy(): void{}

  confirmDelete(card:Cards): void{
    console.log("Confirm deleting now.", card);
    this.deleting = true;
    this.editing = false;
    this.adding = false;
  }
  getEditForm(card:Cards): void{
    console.log("Get Edit Form now.", card);
    this.cardEdit = card;
    this.editing = true;
    this.adding = false;
    this.deleting = false;
  }
  getAddForm(): void{
    console.log("Get Add Form now.");
    this.adding = true;   
    this.editing = false; 
    this.deleting = false;
  }
  cancel(): void{
    console.log("Cancel operation now.");
    this.adding = false;  
    this.editing = false;  
    this.deleting = false;
  }
  switchView(): void{
    if(this.view == 'card'){
      this.view = 'table';
    } else if(this.view == 'table'){
      this.view = 'card';
    }
    console.log("Current view is", this.view);
  }
  private creatForm(): FormGroup{
    let form = new FormGroup({
      cardId: new FormControl(''),
      question: new FormControl(''),
      answer: new FormControl(''),
      status: new FormControl('')
    })
    // let form = this.formBuilder.group({
    //   cardId: [''],
    //   quesiton: [''],
    //   answer: [''],
    //   status: ['']
    // })
    return form;
  }
  getAllCards(): void{
    this.cardsService.getAllCards()
      .subscribe({
        next:cards=>{
        this.cards = cards;
        console.log(cards);
      },
      error:(response)=>{
        console.log(response);
      }
      });
  }
  addCard(): void{
    var cardForm = this.creatForm();
    const cardId = '00000000-0000-0000-0000-000000000000';
    const question = cardForm.controls['question'].value;  
    const answer = cardForm.controls['answer'].value;  
    const status = cardForm.controls['status'].value;  
    const cardAdd: Cards = {question, answer, status} as Cards;
    console.log("before add card triggers", cardAdd);
    this.cardsService.addCard(cardAdd)
      .subscribe({
        next:(card=>{
          this.cards.push(card);
          console.log("adding card now ", card);
        }),
        error:(response)=>{
          console.log(response);
        }
      })
  }
  editCard(): void{
    this.editing = false;
  }
  deleteCard(card:Cards): void{
    this.deleting = false;
    this.cardsService.deleteCardById(card.cardId).subscribe();
  }
}
