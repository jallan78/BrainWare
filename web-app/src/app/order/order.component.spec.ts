import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { OrderComponent } from './order.component';

describe('OrderComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OrderComponent, RouterTestingModule],
    }).compileComponents();
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(OrderComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h1')?.textContent).toContain(
      'Welcome web-app'
    );
  });

  it(`should have as title 'order'`, () => {
    const fixture = TestBed.createComponent(OrderComponent);
    const order = fixture.componentInstance;
    expect(order.title).toEqual('web-app');
  });
});
